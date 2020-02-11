(defblock :name message-unsubscribe :is-top t
	(worker
		:worker-name message-unsubscribe
		:verb "remove"
		:description "Removes a subscription to the subscriber."
		:usage-samples (
			"sub remove '24cc3cd5-c586-44f4-b773-b71ab21b629d'"))

	(end)
)
