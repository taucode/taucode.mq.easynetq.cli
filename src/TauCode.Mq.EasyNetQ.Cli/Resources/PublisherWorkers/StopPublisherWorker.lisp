(defblock :name stop-publisher :is-top t
	(worker
		:worker-name stop-publisher
		:verb "stop"
		:description "Stops the publisher."
		:usage-samples (
			"pub stop"))

	(end)
)
